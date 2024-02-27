using Renci.SshNet;
using System.Text.RegularExpressions;

var method = new PasswordAuthenticationMethod("johnburitto", "10utezez");
var connection = new ConnectionInfo("127.0.0.1", 2000, "johnburitto", method);
var client = new SshClient(connection);

client.Connect();

IDictionary<Renci.SshNet.Common.TerminalModes, uint> modes =
new Dictionary<Renci.SshNet.Common.TerminalModes, uint>
{
    { Renci.SshNet.Common.TerminalModes.ECHO, 53 }
};

ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, modes);

var output = shellStream.Expect(new Regex(@"[$>]"));
Console.WriteLine(output);
shellStream.WriteLine("sudo apt install neofetch");
output = shellStream.Expect(new Regex(@"([$#>:])"));
Console.WriteLine(output);
shellStream.WriteLine("10utezez");
output = shellStream.Expect(new Regex(@"[$>]"));
Console.WriteLine(output);
shellStream.WriteLine("apt list | neofetch");
output = shellStream.Expect(new Regex(@"[$>]"));
Console.WriteLine(output);
shellStream.WriteLine("sudo apt remove neofetch");
output = shellStream.Expect(new Regex(@"([$#>:])"));
Console.WriteLine(output);
shellStream.WriteLine("Y");
output = shellStream.Expect(new Regex(@"[$>]"));
Console.WriteLine(output);