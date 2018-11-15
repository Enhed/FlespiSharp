# FlespiSharp

var connection = new Connection("your token");
var deviceService = new DeviceService(connection);

var all = await deviceService.Get(); // get all devices
Console.WriteLine(JsonConvert.SerializeObject(all));

var galileo = await deviceService.Get("name=*galileo*"); // get devices with contains galileo
Console.WriteLine(JsonConvert.SerializeObject(galileo));

connection.Dispose();