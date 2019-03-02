FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/reviews/service
WORKDIR /otakushelter/reviews/service/src/OtakuShelter.Reviews.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/reviews/service
COPY --from=build /otakushelter/reviews/service/src/OtakuShelter.Reviews.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Reviews.Web.dll"] 