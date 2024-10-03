
# DOMAIN : 
    - là tầng chứa logic nghiệp vụ
    - những logic phức tạp nên đặt ở domain

# INFRASTRUCTURE :
    - là tầng cấu hình cơ sở dữ liệu
    - là tầng tạo triển khai Irepository từ domain và dùng các context
    - là tầng thao tác với cơ sở dữ liệu

# APPLICATION: 
    - Là tầng trên cùng,



# Build vocabulary service 
  ** cd ..

    docker build -f Vocap.API/Dockerfile -t vocabularyservice .
  ** create new network :
  
    docker network ls
  ** add container to network :

	Docker run -d --name vocabularyservice -p 8080:8080 --network <yournetwork> vocabularyservice

  **