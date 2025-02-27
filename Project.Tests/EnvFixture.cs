using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace Project.Tests
{
    internal class EnvFixture
    {
        public EnvFixture()
        {
            DotNetEnv.Env.Load("C:\\Users\\comac\\source\\repos\\GithubCLI\\GithubCLI\\.env");

        }
    }
}
