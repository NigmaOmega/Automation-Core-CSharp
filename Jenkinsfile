pipeline {
     agent any

    tools{
        dotnetsdk 'dotnet'
    }

    stages {
        stage('Tests') {
            steps {
                sh dotnet test ${workspace}/Core-DotnetCore.sln
            }
        }
    }
}


