using Microsoft.AspNetCore.ProtectedBrowserStorage;
using MonctonUG.BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.BlazorServer.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private static Dictionary<Guid, SessionState> _sessionStates = new Dictionary<Guid, SessionState>();

        public SessionManager(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task<SessionState> GetState()
        {
            var sessionId = await _sessionStorage.GetAsync<Guid?>("sessionId");
            if (!sessionId.HasValue)
            {
                sessionId = Guid.NewGuid();
                await _sessionStorage.SetAsync("sessionId", sessionId);
            }

            if (!_sessionStates.ContainsKey(sessionId.Value))
            {
                _sessionStates.Add(sessionId.Value, new SessionState());
            }

            return _sessionStates[sessionId.Value];
        }
    }
}