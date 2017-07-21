﻿using System.Collections.Generic;

namespace cqrs_angular2_nosql.VM.Common
{
    public class ResultServiceVM
    {
        public ResultServiceVM()
        {
            this.Messages = new List<string>();
            this.SuccessMessage = null;
        }

        public bool Success
        {
            get
            {
                return this.Messages.Count == 0;
            }
        }

        public List<string> Messages { get; set; }

        public string SuccessMessage { get; set; }
    }
}
