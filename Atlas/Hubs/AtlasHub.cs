﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Atlas.Models;

namespace Atlas.Hubs
{
	[HubName("AtlasHub")]
	public class AtlasHub : Hub
	{
        public void ChangePage(Message message)
        {
            Clients.All.changePage(message);
        } 

        public void ChangePostNames(Message message)
		{
            Clients.All.changePostNames(message); 
		}

        public void ChangeCommentNames(Message message)
        {
            Clients.All.changeCommentNames(message);
        }

	}
}