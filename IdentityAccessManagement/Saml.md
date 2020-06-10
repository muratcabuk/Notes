### Saml

https://www.youtube.com/watch?v=0fmNoqz6Urw

https://duo.com/blog/the-beer-drinkers-guide-to-saml (detaylı anlatım)

https://developer.okta.com/docs/concepts/saml/ (okta anlatım)


**IDP / SP vs. OP / RP**
In SAML, the user is redirected from the Service Provider (SP) to the Identity Provider (IDP) for sign in.

In OpenID Connect, the user is redirected from the Relying Party (RP) to the OpenID Provider (OP) for sign in.

The SAML SP is always a website. The OpenID Connect RP is either a web or mobile application, and is frequently called the “client” because it extends an OAuth 2.0 client.

In both cases, the IDP/OP controls the login to avoid exposing secrets (like passwords) to the website or app.