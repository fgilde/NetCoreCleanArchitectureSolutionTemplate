﻿namespace $safeprojectname$.Contracts
{
    public interface IJsonSerializer
    {
        string Serialize(object value);
        T Deserialize<T>(string value);
    }
}
