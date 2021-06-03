An example of how to use server side credentials to generate temporary S3 credentials to upload a file from the web browser client

Example S3 CORS configuration
```
[
    {
        "AllowedHeaders": [
            "*"
        ],
        "AllowedMethods": [
            "PUT",
            "POST",
            "DELETE"
        ],
        "AllowedOrigins": [
            "*"
        ],
        "ExposeHeaders": [
          "ETag"
        ]
    }
]
```