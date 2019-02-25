FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

COPY src/ ./src/
COPY build.sh .

RUN ./build.sh all

# Build runtime image
FROM microsoft/dotnet:2.1.1-aspnetcore-runtime
WORKDIR /app

COPY --from=build-env /app/output .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "TrafficSignalsConfigurator.Web.dll"]