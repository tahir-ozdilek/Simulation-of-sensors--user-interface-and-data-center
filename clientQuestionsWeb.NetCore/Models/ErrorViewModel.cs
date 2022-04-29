using System;

namespace clientQuestionsWeb.NetCore.Models
{
    public class PersonModel
    {
        /// Gets or sets PersonId.
        public int PersonId { get; set; }

    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
