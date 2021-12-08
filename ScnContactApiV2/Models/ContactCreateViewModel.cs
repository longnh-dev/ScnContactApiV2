using System;

namespace ScnContactApiV2.Models
{
    public class ContactCreateViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Opinion { get; set; }
        public DateTime DateCreated { get; set; }

    }
}