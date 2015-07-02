using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("LocationCollection")]
public class LocationContainer
{
	[XmlArray("Locations"),XmlArrayItem("Location")]
	public Location[] locations;
	
	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(LocationContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static LocationContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(LocationContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as LocationContainer;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static LocationContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(LocationContainer));
		return serializer.Deserialize(new StringReader(text)) as LocationContainer;
	}
}
