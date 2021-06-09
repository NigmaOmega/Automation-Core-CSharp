using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// JSON Serialization and Deserialization Assistant Class
/// </summary>
public static class JsonHandler
{
    /// <summary>
    /// JSON Serialization
    /// </summary>
    public static string ToJson<T>(this T t)
    {
        var result = JsonConvert.SerializeObject(t);
        return result;
    }

    /// <summary>
    /// JSON Deserialization
    /// </summary>
    public static T ToObject<T>(this string jsonString)
    {
        var result = JsonConvert.DeserializeObject<T>(jsonString);
        return result;
    }


    /// <summary>
    /// JSON Deserialization to list object
    /// </summary>
    public static List<T> ToListObject<T>(this string jsonString)
    {
        List<T> result = JsonConvert.DeserializeObject<List<T>>(jsonString);

        return result;
    }

    /// <summary>
    /// JSON Serialization list object
    /// </summary>
    public static string ToJson<T>(this List<T> listObject)
    {
        var result = JsonConvert.SerializeObject(listObject, Formatting.Indented);
        return result;
    }

    private static JToken JsonObjectGetJValue(this string jsonString, string path)
    {
        var jObject = JObject.Parse(jsonString);
        var result = jObject.SelectToken(path);

        return result;
    }

    private static JToken JsonArrayGetJValue(this string jsonString, string path)
    {
        var jArray = JArray.Parse(jsonString);
        var result = jArray.SelectToken(path);

        return result;
    }

    /// <summary>
    /// Get json value by path
    /// </summary>
    public static JToken GetJsonValue(this string jsonString, string path)
    {
        try
        {
            return JsonObjectGetJValue(jsonString, path);
        }
        catch
        {
            return JsonArrayGetJValue(jsonString, path);
        }
    }

    /// <summary>
    /// Update json value by path
    /// </summary>
    public static JToken UpdateJsonValue(this string jsonString, string path, string value)
    {
        var JsonData = jsonString.GetJsonValue("");
        var JsonWithPath = JsonData.SelectToken(path);
        JsonWithPath.Replace(JToken.Parse(value));
        return JsonData;
    }

    /// <summary>
    /// Validate the Json string
    /// </summary>
    public static bool IsValidJson(this string input)
    {
        try
        {
            JToken.Parse(input);
            return true;
        }
        catch (JsonReaderException ex)
        {
            Trace.WriteLine(ex);
            return false;
        }
    }
}

