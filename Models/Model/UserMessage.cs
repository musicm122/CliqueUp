using System;
using Models.Model;

namespace CliqueUpModel.Model
{
    public class UserMessage
    {
        public Guid Id { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}
