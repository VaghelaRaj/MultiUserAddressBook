using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Encrypt_Decrypt : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page_Load

    #region btnencrypt_Click
    protected void btnencrypt_Click(object sender, EventArgs e)
    {
        lblencrypt.Text = Base64Encode(txtencrypt.Text.Trim());
        
    }
    #endregion btnencrypt_Click

    #region encrypt
    private string encrypt(string ClearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(ClearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                ClearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return ClearText;
    }
    #endregion encrypt

    #region Decrypt
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212 ";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    #endregion Decrypt

    #region btndecrypt_Click

    protected void btndecrypt_Click(object sender, EventArgs e)
    {
        lbldecrypt.Text = Base64Decode(lblencrypt.Text.Trim());
    }
    #endregion btndecrypt_Click

    #region Base64Encode
    private string Base64Encode(string plainText)
    {
        var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plaintextbytes);
    }
    #endregion Base64Encode

    #region Base64Decode

    private string Base64Decode(string Base64EncodedData)
    {
        var base64encodedbytes = System.Convert.FromBase64String(Base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64encodedbytes);
    }
    #endregion Base64Decode


}