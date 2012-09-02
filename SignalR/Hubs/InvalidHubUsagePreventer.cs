using System;
using System.Dynamic;

namespace SignalR.Hubs
{
    public class InvalidHubUsagePreventer : DynamicObject
    {
        private const string InvalidHubUsageMessage = "You are using a hub instance that was not created by SignalR, which is an unsupported scenario! Use 'GlobalHost.GlobalHost.ConnectionManager.GetHubContext<T>()' to get ahold of the context object for a hub that let's you do broadcasting.";

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            throw new InvalidOperationException(InvalidHubUsageMessage);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            throw new InvalidOperationException(InvalidHubUsageMessage);
        }
    }
}
