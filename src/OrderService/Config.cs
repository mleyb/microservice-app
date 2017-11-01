using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderService
{
    public class Config
    {
        private static Dictionary<string, string> _values = new Dictionary<string, string>();

        public static string MessageQueueUrl { get { return Get("MESSAGE_QUEUE_URL"); } }
        
        private static string Get(string name)
        {
            if (!_values.ContainsKey(name))
            {
                var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);

                if (string.IsNullOrEmpty(value))
                {
                    value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);

                    Console.WriteLine($"Environment variable with name {name} was read with value {value}");
                }                

                _values[name] = value;
            }
            return _values[name];
        }
    }
}