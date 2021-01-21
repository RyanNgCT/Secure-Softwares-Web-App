# Secure-Softwares-Web-App

Web App created for a fictitious software sales company using ASP .NET Razor Pages.

In this project, we aim to create a web application that sells software products. The goal of this webpage is to ensure that users have a secure distribution service to purchase their softwares from. The webpage must provide authentication and authorisation to provide better security, and must also be resistant to cyberattacks such as SQL injection attacks, Cross-Site Request Forgery (CSRF) attacks and Cross-Site Scripting (XSS) attacks. Whilst having security safeguards, the website should also not compromise on its usability so that users can use it intuitively as intended as a secure software sales web application.

[Notes by devs](https://docs.google.com/document/d/1SxIXTsnp0RhG702WcIClbmqBboJuLbTKRk2pcdqdYdo/edit?usp=sharing) on local webapp usage.

## Requirements
- Microsoft Visual Studio > 16.0
- IIS Express Server
- ASP .NET Core __3.1__
- Create your own API keys for Email (Sendgrid), Captcha and Google Authentication in `secrets.json`. [Tutorial](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows) on this topic.
- Code in this repo

```
git clone https://github.com/RyanNgCT/Secure-Softwares-Web-App.git
```


## Features

| Name    | Features                                                                                                                                                       |Done?| 
|---------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|------|
| Ryan    | Authentication, Login, Registration 2FA, Email Confirmation & Password Reset, Sign in with Google, Privacy Policy                                                 | ✔️  |
| Kai Zer | Authorization, Roles management (Create various admin roles and User roles, Automated Role Allocation), CAPTCHA in registration and login page | ✔️  | 
| Ray Son | CRUD Database (Software Products Page), Auditing, Error Management & Session Management                                                                            | ✔️  |  
| Gerald  | Review Page, Checkout Page                                                                                                                                      | ✔️  |  
