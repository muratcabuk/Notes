### Federated identity and ADFS

- https://wso2.com/articles/2018/06/what-is-federated-identity-management/

- https://www.mshowto.org/active-directory-federation-services-nedir.html

- https://www.hakanuzuner.com/active-directory-federation-services-nedir/

- https://www.okta.com/identity-101/single-sign-on-ADFS-vs-LDAP/ (ADFS vs LDAP)



Federation is a concept whereby users from company A can authenticate to an application on company B but using their company A credentials.

It uses one of three federation protocols to do this:

- SAML 2.0
- WS-Federation
- OpenID Connect

The result is a SAML token or a JWT (OpenID Connect) that contains a set of attributes from an AD for that user. These list of attributes to provide are configured in ADFS via claims rules and the attributes in the token are referred to as claims.


### ADFS vs Azure Active Directory

https://www.youtube.com/watch?v=IhmNXSNL2zg


Azure AD and AD FS share similar roles in an IT environment. Both Microsoft tools share SSO-like properties, and they each need to work in tandem with on-prem Active Directory (although Azure AD could possibly be used without).

Although both solutions are similar, they each have their own distinctions. Azure AD has wider control over user identities outside of applications than AD FS, which makes it a more widely used and useful solution for IT organizations. Both Azure AD and AD FS share one critical similarity, though: neither are true directory services nor standalone services. That means that IT organizations using Azure AD or AD FS usually require a directory service like Active Directory, as well as any other add-on solutions AD requires.

IT organizations need the adaptability to support any resources their end users require, regardless of their protocol, platform, provider, or location. By sticking to just Azure AD or AD FS on top of their AD instance, IT organizations essentially lock themselves into Windows systems and a select group of web applications.

Organizations looking to unify their identity management often need to venture outside the Microsoft family of products. After all, Microsoft is no longer the only player in the IT game; IT organizations need to find a solution that can accommodate virtually all IT resources. 

