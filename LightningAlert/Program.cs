using DTN_lightning_alert.Data;
using LightningAlert;
using Newtonsoft.Json;

List<Asset> assets = new List<Asset>();

using (StreamReader sr = new StreamReader("assets.json"))
{
    string json = sr.ReadToEnd();
    assets = JsonConvert.DeserializeObject<List<Asset>>(json);
}

List<Lightning> lightning = new List<Lightning>();

using (StreamReader sr = new StreamReader("lightning.json"))
{
    string line;
    Lightning lightningInput = new Lightning();
    List<string> impactedAreas = new List<string>();
    while ((line = sr.ReadLine()) != null)
    {
        try
        {
            lightningInput = JsonConvert.DeserializeObject<Lightning>(line);
            lightning.Add(lightningInput);

            string impactedArea = TileSystem.LatLongToQuadKey(lightningInput.Latitude, lightningInput.Longitude, 12);
            Asset asset = assets.FirstOrDefault(x => x.QuadKey == impactedArea);
            if (asset != null && !impactedAreas.Any(x => x == impactedArea))
            {
                Console.WriteLine($"lightning alert for {asset.Owner}:{asset.Name}");
                impactedAreas.Add(impactedArea);
            }
        }
        catch (Exception ex)
        {
            //can be substituted with another logger. for now we can just print the error
            //Console.WriteLine(ex.Message);
        }
    }
}

Console.WriteLine($"Press any key to close");
Console.ReadLine();
