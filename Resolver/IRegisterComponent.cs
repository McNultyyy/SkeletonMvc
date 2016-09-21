using System;

namespace Resolver
{
    public interface IRegisterComponent
    {
        void RegisterType(Type from, Type to, bool withInterception = false);
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        void RegisterTypeWithControlledLifeTime(Type from, Type to, bool withInterception = false);
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}