using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Engine.Setup;

namespace Engine.TestRail
{
    public class TestRailIntegration 
    {
        /// <summary>
        /// Method to Publish test results to Test Rail
        /// </summary>
        /// <param name="testCaseId">Test Case Id </param>
        /// <param name="status">Status of the test execution</param>
        public static string PublishResultsToTestRail(string testCaseId, string status)
        {
            try
            {
                string projectId = "", milestoneId = "", testSuiteId = "", userId = "", testId = "",errorMessage="";
                Dictionary<string, object> testResult = new Dictionary<string, object>();
                testCaseId = testCaseId.Substring(1);

                #region Login to Test Rail
                APIClient client = new APIClient(EngineSetup.TESTRAILURL);
                client.User = EngineSetup.TESTRAILUSERID; //Put the e-mail of your user here
                client.Password = EngineSetup.TESTRAILPASSWORD;//Put the password of your user here
                #endregion

                #region Retrieve Project Id
                //Returns the list of projects
                var response = client.SendGet("get_projects");
                var projects = JsonConvert.DeserializeObject<GetProjects[]>(response.ToString());
                foreach (var project in projects)
                {
                    if (project.name.Trim().ToUpper() == EngineSetup.TESTRAILPROJECT.Trim().ToUpper())
                    {
                        projectId = project.id.ToString();
                        break;
                    }
                }

                if (projectId == "")
                {
                    errorMessage = "Failed to get project Id for project: "+ EngineSetup.TESTRAILPROJECT + ", please provide a valid project name";
                    return errorMessage;
                }
                #endregion
                
                #region Retrive User Id
                if (EngineSetup.TESTRAILASSIGNEDTO.Trim() != "")
                {
                    response = client.SendGet("get_users");
                    var users = JsonConvert.DeserializeObject<GetUsers[]>(response.ToString());
                    foreach (var user in users)
                    {
                        if (user.name.Trim().ToUpper() == EngineSetup.TESTRAILASSIGNEDTO.Trim().ToUpper())
                        {
                            userId = user.id.ToString();
                            break;
                        }
                    }

                    if (userId == "")
                    {
                        errorMessage = "Failed to get userId for user: " + EngineSetup.TESTRAILASSIGNEDTO + ", please provide a valid user name";
                        return errorMessage;
                    }
                }
                #endregion

                #region Retrieve Status Id
                int statusId = 0;
                response = client.SendGet("get_statuses");
                var testStatuses = JsonConvert.DeserializeObject<TestStatus[]>(response.ToString());
                foreach (var stat in testStatuses)
                {
                    if (stat.label.ToUpper() == status.ToUpper())
                    {
                        statusId = stat.id;
                        break;
                    }
                }
                #endregion

                #region Retrieve Milestone Id
                //Returns the list of milestones for a project.
                response = client.SendGet("get_milestones/" + projectId);//3637 --Test suite
                var milestones = JsonConvert.DeserializeObject<GetMilestones[]>(response.ToString());
                foreach (var milestone in milestones)
                {
                    if (milestone.name.Trim().ToUpper() == EngineSetup.TESTRAILMILESTONE.Trim().ToUpper())
                    {
                        milestoneId = milestone.id.ToString();
                        break;
                    }
                }


                if (milestoneId == "")
                {
                    errorMessage = "Failed to get milestone Id for milestone: "+ EngineSetup.TESTRAILMILESTONE + ", please provide a valid milestone name";
                    return errorMessage;
                }
                #endregion

                #region Retrieve Test Suites 
                //Returns a list of test suites for a project.
                response = client.SendGet("get_suites/" + projectId);//3637 --Test suite
                var testSuites = JsonConvert.DeserializeObject<GetTestSuites[]>(response.ToString());
                foreach (var testsuite in testSuites)
                {
                    if (testsuite.name.Trim().ToUpper() == EngineSetup.TESTRAILSUITE.Trim().ToUpper())
                    {
                        testSuiteId = testsuite.id.ToString();
                        break;
                    }
                }
                #endregion

                #region Create new Test Run 
                string testRunName = EngineSetup.TESTRAILTESTRUNNAME + " - " + DateTime.Now.ToString("MMddyyyy");
                response = client.SendGet("get_runs/" + projectId);
                var testRuns = JsonConvert.DeserializeObject<GetRuns[]>(response.ToString());
                string existingTestRunId = "";
                foreach (var run in testRuns)
                {
                    if (run.name.Trim().ToUpper() == testRunName.ToUpper() && run.milestone_id.ToString() == milestoneId)
                    {
                        existingTestRunId = run.id.ToString();
                        break;
                    }
                }

                List<string> caseIds = new List<string>();

                if (existingTestRunId == "")
                {
                    caseIds.Add(testCaseId);
                    testResult["suite_id"] = testSuiteId; 
                    testResult["name"] = testRunName;
                    testResult["description"] = testRunName;
                    testResult["milestone_id"] = milestoneId;
                    testResult["assignedto_id"] = userId;
                    testResult["include_all"] = false; // false if adding specific tests, true if all tests have to be added
                    testResult["case_ids"] = caseIds.ToArray();//[1, 2, 3, 4, 7, 8]; 
                    response = client.SendPost("add_run/" + projectId, testResult);
                    var testRunResponse = JsonConvert.DeserializeObject<AddTestRun>(response.ToString());
                    existingTestRunId = testRunResponse.id.ToString();
                }
                #endregion

                #region Add Tests to Test Run
                response = client.SendGet("get_tests/" + existingTestRunId);
                var testsList = JsonConvert.DeserializeObject<GetTests[]>(response.ToString());
                foreach (var test in testsList)
                {
                    if (test.case_id.ToString() == testCaseId)
                    {
                        testId = test.id.ToString();
                        break;
                    }
                    else
                    {
                        caseIds.Add(test.case_id.ToString());
                    }
                }

                if (testId == "")
                {
                    caseIds.Add(testCaseId);
                    testResult["include_all"] = false;
                    testResult["case_ids"] = caseIds.ToArray();//[1, 2, 3, 4, 7, 8];
                    response = client.SendPost("update_run/" + existingTestRunId, testResult);

                    response = client.SendGet("get_tests/" + existingTestRunId);
                    testsList = JsonConvert.DeserializeObject<GetTests[]>(response.ToString());
                    foreach (var test in testsList)
                    {
                        if (test.case_id.ToString() == testCaseId)
                        {
                            testId = test.id.ToString();
                            break;
                        }
                    }
                }
                #endregion
                                
                #region Publish Test Results
                testResult = new Dictionary<string, object>();
                testResult["status_id"] = statusId; 
                testResult["comment"] = "Automated Test - "+status;
                testResult["assignedto_id"] = userId;
                response = client.SendPost("add_result/" + testId, testResult);//3637 --Test suite
                #endregion

                return errorMessage;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Exception occurred while publishing results to Test Rail. Exception Details: "+ex.Message;
            }
        }

    }
}
