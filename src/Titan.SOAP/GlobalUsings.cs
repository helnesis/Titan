global using Titan.SOAP.Base.Client;
global using Titan.SOAP.Base.Command.Definitions;
global using System.Net;
global using System.Text;
global using System.Xml;
global using Titan.SOAP.Base.Command;
global using Titan.SOAP.Base.Command.Definitions;
global using Titan.SOAP.Settings;
global using System;
global using System.Collections.Generic;

global using GameCommandMap = System.Collections.Generic.Dictionary<Titan.SOAP.Base.Command.Definitions.GameCommand, string>;
global using GameCommandCallback = System.Func<Titan.SOAP.Base.Command.Definitions.GameCommand, string[], System.Threading.Tasks.Task<Titan.SOAP.Base.Client.SoapResponse>>;