# tilsyn-automat
BOSS - løsning for selvdeklarering av automater


#Inställingar
secrets.json ska ha dessa inställningar: 

{
  "ConnectionStrings": {
    "DefaultConnection": "Server={Server};Database={Database};User ID={User};Password={Password};MultipleActiveResultSets=true"
  },
  "IdPorten": {
    "BaseUrl": "https://oidc-ver2.difi.no/idporten-oidc-provider",
    "ClientId": "{ClientId}",
    "Secret": "{Secret}",
    "Nonce": "{RandomString}",
    "RedirectUrl": "https://localhost:44343/LoginHandler",
    "LogoutUrl": "https://localhost:44343/LogoutHandler"
  },
  "Azure": {
    "StorageAccountName": "{StorageAccountName}",
    "StorageAccountKey": "{StorageAccountKey}",
    "StorageContainer": " {StorageContainer}"
  },
  "Log": {
    "Active": true,
    "LogGetSucceeded": false,
    "LogChangeSucceeded": true,
    "LogError": true,
    "LogLongTime": 500
  },
  "Api": {
    "Key": "{RandomString}"
  }
}
