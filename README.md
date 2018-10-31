# tilsyn-automat
BOSS - løsning for selvdeklarering av automater


#Inställingar
secrets.json ska ha dessa inställningar: 

{
  "ConnectionStrings": {
    "DefaultConnection": ""
  },
  "IdPorten": {
    "BaseUrl": "https://oidc-ver2.difi.no/idporten-oidc-provider",
    "ClientId": "",
    "Secret": "",
    "Nonce": "",
    "RedirectUrl": "https://localhost:44343/LoginHandler"
  }
}
