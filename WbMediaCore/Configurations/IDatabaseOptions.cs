﻿namespace WbMediaCore.Configurations
{
    public interface IDatabaseOptions
    {
        string Server { get; set; }
        string Database { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
    }
}
