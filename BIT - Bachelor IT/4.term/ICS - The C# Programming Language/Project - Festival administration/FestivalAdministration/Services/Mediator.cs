﻿using System;
using System.Collections.Generic;
using System.Linq;
using FestivalAdministration.BL.Interfaces;
using FestivalAdministration.Services;

namespace CookBook.BL.Services
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, List<Delegate>> _registeredActions = new();

        public virtual void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);
            if (!_registeredActions.TryGetValue(key, out _)) _registeredActions[key] = new List<Delegate>();
            _registeredActions[key].Add(action);
        }

        public virtual void UnRegister<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);

            if (_registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                var actionsList = actions.ToList();
                actionsList.Remove(action);
                _registeredActions[key] = new List<Delegate>(actionsList);
            }
        }

        public virtual void Send<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            if (!_registeredActions.TryGetValue(typeof(TMessage), out var actions)) return;
            foreach (var action in actions.Select(action => action as Action<TMessage>).Where(action => action != null)
                .ToList()) action(message);
        }
    }
}