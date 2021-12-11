﻿using Marina_Club.Validators.Message;

namespace Marina_Club.Commands.Message
{
    public class SearchMessageCommand : CommandBase
    {
        /// <summary>
        /// باکس جست و جو
        /// </summary>
        public string SearchBox { get; set; }

        public override bool Validate()
        {
            return new SearchMessageCommandValidator().Validate(this).IsValid;
        }
    }
}
