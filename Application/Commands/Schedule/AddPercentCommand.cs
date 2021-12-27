using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Schedule
{
    public class AddPercentCommand : CommandBase
    {

        public Guid Id { get; set; }
        public int Value { get; set; }
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
