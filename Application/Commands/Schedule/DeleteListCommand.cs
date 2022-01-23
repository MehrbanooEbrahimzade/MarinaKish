using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Schedule
{
    public class DeleteListCommand : CommandBase
    {
        public List<Guid> IDs { get; set; }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
