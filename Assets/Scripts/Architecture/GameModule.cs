using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CloudeDev.Architecture
{
    public abstract class GameModule : MonoBehaviour
    {
        public virtual IEnumerable<object> GetServices()
        {
            Type type = GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
                );
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(Service)))
                {
                    yield return field.GetValue(this);
                }
            }

        }
        public virtual IEnumerable<IGameListeners> GetListeners()
        {
            Type type = GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
                );
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(Listener)))
                {
                    var value = field.GetValue(this);
                    if (value is IGameListeners gameListeners)
                    {
                        yield return gameListeners;
                    }

                }
            }
        }

        public virtual void ResolveDependencies(GameSystem gameSystem)
        {
            Type type = GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
                );

            foreach (FieldInfo field in fields)
            {
               var target = field.GetValue(this);
                gameSystem.Inject(target);
            }
        }

    }
}
