using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderProcessorService
{
    public class Config
    {
        private static Dictionary<string, string> _values = new Dictionary<string, string>();

        public static string MessageQueueUrl { get { return Get("MESSAGE_QUEUE_URL"); } }
        
        private static string Get(string variable)
        {
            if (!_values.ContainsKey(variable))
            {
                var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrEmpty(value))
                {
                    value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
                }
                _values[variable] = value;
            }
            return _values[variable];
        }
    }
}