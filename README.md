[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<p align="center">
    <img src="https://snmpcenter.com/wp-content/uploads/2016/10/RESTful-API-logo-for-light-bg.png" alt="RESTful API Logo" width="100">
    <img src="https://unop.uk/content/images/2017/08/NET-Core-Logo-1.png" alt=".NET Core Logo" width="100">

  <h3 align="center">RESTful APIs in .NET Core</h3>
</p>

<!-- TABLE OF CONTENTS -->

## Table of Contents

- [About the Repo](#about-the-project)
  - [Built With](#built-with)
- [Contributing](#contributing)
- [Contact](#contact)

<!-- ABOUT THE PROJECT -->

## About The Project

### HTTP Requests

The way that the web works is important to understand when we're designing and building APIs. In a standard request, there is user that wants to make a request to a server. This might be for a web page, an API, a JavaScript file, an image, etc. The request itself has three pieces, a **verb**, which is what you want to do, headers, which include additional information, and then the actual content. In the case of a simple request for a web page, a content might actually be missing.

The most common of these is **GET**. _Hey server, I want you to give me something that you have._ And this is essentially to retrieve a resource. You can think about a GET as _hey server, please give me this webpage_ or _hey server, please give me this image_ and so on.

**POST** adds a new resource. So POST says _hey server, go create me a new one of these_. And this is the data that's related to the new object that I want you to create.

The **PUT** verb updates an existing resource. So essentially it says _here's the data that I may have retrieved from you earlier with some changes, please update it with these changes, kind server_.

**PATCH** is something that's not as commonly used, and while it's kind of similar to PUT, their main difference between them is in the way processes the enclosed entity to modify the resource. In the PUT request, the data we are sending to the server, as far as the server is concerned, might be completely different than what the previous resource was, while a PATCH requests contains a set of instruction describing how the resource that is currently residing on the server should be modified to produce a new version. Also, another difference is that when you want to update a resourse with a PUT request, you have to send the full payload as the request, whereas with PATCH you only send the parameters which you want to update.

And lastly, **DELETE** which does exactly what the name suggests, it deletes a specific resource on the server.

There are actually more HTTP request methods than the ones listed here, but these are the most common. For a full list of all the HTTP request methods that goes more in depth in to what each of them does, [click here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)

### REST

What is **REST**?

REST stands for **RE**presentational **S**tate **T**ransfer and it's basically an architectural style for providing certain standars in the communication between computer systems on the web. When a system or an API is compliant to these standards, we call that a RESTful API.

Basic concepts are :

- Seperating the client data from the server data
- All requests to the server are stateless
- The requests themselves can be cachable
- The requests use a URI or uniform interface

### What are URIs?

So when we're talking about REST, we're normally talking about a URI that needs to point at a resource. And by resource I mean any type of data that a user might interact with, whether that is a product on the website, a payment, another user, etc. While we're designing our APIs, we're going to want to think about what the actual address is to these APIs. They're what we call **URIs**, or Uniform Resource Identifiers. These URIs are just paths to the resources within our system.

#### Optional Arguments

**Query strings** can be used for non-data elements. So, when we start to think about formatting, sorting and searching, that's where query strings come in, because they're not part of the URI itself, they're optional arguments to those URIs or to those resources.

#### What are we going to be bulding?

We're going to be bulding something for a Codecamp! We have the idea that one camp will be related to one location. Each camp will have a set of talks for the actual presentations that will be taking place, and each talk is going to have a speaker associated with it.

### Built With

- [.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/ef6/)

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AwesomeFeature`)
3. Commit your Changes (`git commit -m 'Add some AwesomeFeature`)
4. Push to the Branch (`git push origin feature/AwesomeFeature`)
5. Open a Pull Request

<!-- CONTACT -->

## Contact

Matthew Dodi - [in/MatthewDodi](https://linkedin.com/in/MatthewDodi) - matthew.dodi@gmail.com

Project Link: [https://github.com/MatthewDodi/RESTful-.NET-Core.git](https://github.com/MatthewDodi/RESTful-.NET-Core.git)

<!-- MARKDOWN LINKS & IMAGES -->

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/MatthewDodi
