﻿namespace SharpBucket.V2.Pocos
{
    public class User
    {
        public string username { get; set; }
        public string kind { get; set; }
        public string website { get; set; }
        public string display_name { get; set; }
        public Links links { get; set; }
        public string created_on { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
    }
}