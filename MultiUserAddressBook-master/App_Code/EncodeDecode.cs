
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncodeDecode
/// </summary>
public static class EncodeDecode
{

    public static string Base64Encode(String PlainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(String Base64EncodeData)
    {
        var Base64EncodedBytes = System.Convert.FromBase64String(Base64EncodeData);
        return System.Text.Encoding.UTF8.GetString(Base64EncodedBytes);
    }
}