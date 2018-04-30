﻿namespace DynamicDns.Core.Dto
{
    public class RecordDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Priority { get; set; }
        public int Ttl { get; set; }
        public string Service { get; set; }
        public string Protocol { get; set; }
        public int Port { get; set; }
        public int Weight { get; set; }
    }
}
