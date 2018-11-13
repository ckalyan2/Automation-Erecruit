using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TestRail
{
    public class GetProjects
    {
        public int id { get; set; }
        public string name { get; set; }
        public object announcement { get; set; }
        public bool show_announcement { get; set; }
        public bool is_completed { get; set; }
        public object completed_on { get; set; }
        public int suite_mode { get; set; }
        public string url { get; set; }


    }

    public class GetMilestones
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? start_on { get; set; }
        public int? started_on { get; set; }
        public bool is_started { get; set; }
        public int? due_on { get; set; }
        public bool is_completed { get; set; }
        public int? completed_on { get; set; }
        public int project_id { get; set; }
        public object parent_id { get; set; }
        public string url { get; set; }
    }

    public class GetTestSuites
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int project_id { get; set; }
        public bool is_master { get; set; }
        public bool is_baseline { get; set; }
        public bool is_completed { get; set; }
        public object completed_on { get; set; }
        public string url { get; set; }
    }


    public class GetUsers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool is_active { get; set; }
    }

    public class CustomStepsSeparated
    {
        public string content { get; set; }
        public string expected { get; set; }
    }

    public class AddTestRun
    {
        public int id { get; set; }
        public int suite_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int milestone_id { get; set; }
        public int assignedto_id { get; set; }
        public bool include_all { get; set; }
        public bool is_completed { get; set; }
        public object completed_on { get; set; }
        public object config { get; set; }
        public List<object> config_ids { get; set; }
        public int passed_count { get; set; }
        public int blocked_count { get; set; }
        public int untested_count { get; set; }
        public int retest_count { get; set; }
        public int failed_count { get; set; }
        public int custom_status1_count { get; set; }
        public int custom_status2_count { get; set; }
        public int custom_status3_count { get; set; }
        public int custom_status4_count { get; set; }
        public int custom_status5_count { get; set; }
        public int custom_status6_count { get; set; }
        public int custom_status7_count { get; set; }
        public int project_id { get; set; }
        public object plan_id { get; set; }
        public int created_on { get; set; }
        public int created_by { get; set; }
        public string url { get; set; }
    }

    public class GetTests
    {
        public int id { get; set; }
        public int case_id { get; set; }
        public int status_id { get; set; }
        public int? assignedto_id { get; set; }
        public int run_id { get; set; }
        public string title { get; set; }
        public int template_id { get; set; }
        public int type_id { get; set; }
        public int priority_id { get; set; }
        public object estimate { get; set; }
        public object estimate_forecast { get; set; }
        public string refs { get; set; }
        public object milestone_id { get; set; }
        public bool custom_automated { get; set; }
        public int custom_complexity { get; set; }
        public int custom_review_status { get; set; }
        public string custom_case_preconditions { get; set; }
        public string custom_case_description { get; set; }
        public List<CustomStepsSeparated> custom_steps_separated { get; set; }
    }

    public class GetRuns
    {
        public int id { get; set; }
        public int suite_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? milestone_id { get; set; }
        public int? assignedto_id { get; set; }
        public bool include_all { get; set; }
        public bool is_completed { get; set; }
        public int? completed_on { get; set; }
        public object config { get; set; }
        public List<object> config_ids { get; set; }
        public int passed_count { get; set; }
        public int blocked_count { get; set; }
        public int untested_count { get; set; }
        public int retest_count { get; set; }
        public int failed_count { get; set; }
        public int custom_status1_count { get; set; }
        public int custom_status2_count { get; set; }
        public int custom_status3_count { get; set; }
        public int custom_status4_count { get; set; }
        public int custom_status5_count { get; set; }
        public int custom_status6_count { get; set; }
        public int custom_status7_count { get; set; }
        public int project_id { get; set; }
        public object plan_id { get; set; }
        public int created_on { get; set; }
        public int created_by { get; set; }
        public string url { get; set; }
    }

    public class TestStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public int color_dark { get; set; }
        public int color_medium { get; set; }
        public int color_bright { get; set; }
        public bool is_system { get; set; }
        public bool is_untested { get; set; }
        public bool is_final { get; set; }
    }


}
