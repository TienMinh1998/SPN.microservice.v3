pipeline {
    agent any

    stages {
        stage('Clone Repository') {
            steps {
                // Clone kho lưu trữ từ GitHub
                git url: 'https://github.com/TienMinh1998/SPN.microservice.v3.git', branch: 'main' // Hoặc nhánh bạn muốn
            }
        }

        stage('Build') {
            steps {
                // Thêm các bước xây dựng ở đây nếu cần
                echo 'Building the project...'
            }
        }

        stage('Deploy') {
            steps {
                // Thêm các bước triển khai ở đây nếu cần
                echo 'Deploying the project...'
            }
        }
    }
}