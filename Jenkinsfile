pipeline {
    agent any
    stages {
        stage('Tests') {
            steps {
                sh npm i npx
                sh returnStatus: true, script: "npx dotnet test \"${workspace}/Core-DotnetCore.sln\" --logger \"nunit;LogFileName=results.xml\""
                nunit failIfNoResults: true, testResultsPattern: '**/results.xml'
            }
        }
    }
}


