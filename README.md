# .NET-gram

### Azure Deployment

https://dotnetgram.azurewebsites.net/

This web application holds posts of images and details.  Photo Wave contains a Home page that shows all of the posts created, a landing page for each post that shows all the details of the post, the ability to edit the details of a post, and the capability to add and delete posts.  It utilizes the Microsoft Razor pages architectural pattern and integrates the repository design pattern.  

## Usage

The user lands on the home page which displays all posts

![all posts](https://github.com/dezteague/.NET-gram/blob/master/Assets/allposts.JPG)

Users can contribute a new post by clicking the "add new post" link

![add posts](https://github.com/dezteague/.NET-gram/blob/master/Assets/addnewpost.JPG)

In order to make a new post, upload an image, write a title and caption, then click "save"

![upload](https://github.com/dezteague/.NET-gram/blob/master/Assets/choosefile.JPG)

A user may select a specific post to edit

![select for edit](https://github.com/dezteague/.NET-gram/blob/master/Assets/edit.JPG)

The edit page allows users to change the image, title, and caption of the post

![edit post](https://github.com/dezteague/.NET-gram/blob/master/Assets/editpage.JPG)

## Technologies Used

Visual Studio, GitHub, Microsoft.AspNetCore, Microsoft.EntityFramework, Razor Pages, Bootstrap, Azure Blob Storage

## Architectural Design

The database contains a single entity with ID, Title, Caption, and URL

