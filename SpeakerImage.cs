﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Statiq.Common;

namespace DotnetFoundationWeb
{
    // Sets the speaker image metadata if not already provided
    public class SpeakerImage : SyncModule
    {
        protected override IEnumerable<IDocument> ExecuteInput(IDocument input, IExecutionContext context) =>
            input.GetString(SiteKeys.Image).IsNullOrWhiteSpace()
                ? input
                    .Clone(new MetadataItems
                    {
                        { SiteKeys.Image, input.ContainsKey(SiteKeys.GitHub) ? input.GetString(SiteKeys.GitHub) + ".png" : "/img/dot_bot.png" }
                    })
                    .Yield()
                : input
                    .Yield();
    }
}
