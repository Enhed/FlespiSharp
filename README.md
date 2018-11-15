# FlespiSharp

## Get info about all devices

```c#
using System;
using FlespiSharp;
using FlespiSharp.Gateway;

class Program
{
    static async Task Main(string[] args)
    {

        using(var con = new Connection("your token")){
            var result = await con.CreateGateway().Devices.All.Get();

            foreach(var device in result.Values){
                Console.WriteLine($"[{device.Id}] device name {device.Name} with ident {device.Ident} have typeId {device.TypeId}");
            }

            if(result.HasErrors){
                Console.WriteLine("Has Errors in response:");

                foreach(var error in result.Errors){
                    Console.WriteLine($"\t[{error.Code}]: id {error.Id} = {error.Reason}");
                }
            }
        }
    }
}
```