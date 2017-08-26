﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using HRMBot.Extensions;

namespace HRMBot.Dialogs
{
    [LuisModel("6f13a4ce-dabe-485a-bb3f-9aba3156ea95", "5ea418ae538a402a9b99a936389fd0e7", domain: "westus.api.cognitive.microsoft.com", staging: true)]
    [Serializable]
    public partial class RootLuisDialog : LuisDialog<object>
    {
        private string userData;

        public RootLuisDialog(string userData)
        {
            this.userData = userData;
        }

        [LuisIntent("AvailableLeave")]
        public async Task AvailableLeave(IDialogContext context, LuisResult result)
        {
            //(result.Entities).Items[0]).Resolution).Items[0]).Value
            string message = $"You are asking for AvailableLeave. Processing Entity: ";

            message += result.GetResolvedListEntity("LeaveType");

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);


        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"I do not understand {result.Query}. I am learning new things everyday. Try again tomorrow? ";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("AvailedLeave")]
        public async Task AvailedLeave(IDialogContext context, LuisResult result)
        {
            string message = $"You are asking for AvailedLeave. Processing Entity: " + result.GetResolvedListEntity("LeaveType");
           


            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("EntitledLeave")]
        public async Task EntitledLeave(IDialogContext context, LuisResult result)
        {
            string message = $"You are asking for EntitledLeave. Processing Entity: ";
            message += result.GetResolvedListEntity("LeaveType");

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

    }    
}