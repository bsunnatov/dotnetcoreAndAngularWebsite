const PROXY_CONFIG = [
    {
        context: [
            "/api"
        ],
        target: "http://localhost:5050/",//for iisexpress
       // target: "http://localhost:5000/",//for dotnet run
        secure: false
    }
]

module.exports = PROXY_CONFIG;
