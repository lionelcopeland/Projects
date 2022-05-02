Select *
From PortfolioProject..coviddeaths$
Where continent is not null
order by 3,4

--Select *
--From PortfolioProject..covidvaccines$
--order by 3,4

--Select Data that we are going to be using

Select Location, date, total_cases, new_cases, total_deaths, population
From PortfolioProject..coviddeaths$
order by 1,2

--Looking at Total Cases vs Total Deaths

Select Location, date, total_cases, total_deaths,(total_deaths/total_cases)*100 as DeathPercentage
From PortfolioProject..coviddeaths$
Where location like '%states%'
order by 1,2

--Total Cases weighed against population

Select Location, date, total_cases, Population, (total_cases/population)*100 as PercentPopulationInfected
From PortfolioProject..coviddeaths$
Where location like '%states%'
order by 1,2

--Highest Infection Rate in terms of Population

Select Location, Population, MAX(total_cases) AS HighestInfectionCount, MAX((total_cases/population)) *100 as PercentPopulationInfected
From PortfolioProject..coviddeaths$
--Where location like '%states%'
Group by Location, Population
order by PercentPopulationInfected desc

--Countries with highest death count per Population

Select Location, MAX(cast(Total_deaths as bigint)) as TotalDeathCount
From PortfolioProject..coviddeaths$
--Where location like '%states%'
Where continent is not null
Group by Location
order by TotalDeathCount desc

--Continental Breakdown

Select location, MAX(cast(Total_deaths as bigint)) as TotalDeathCount
From PortfolioProject..coviddeaths$
--Where location like '%states%'
Where continent is null
Group by location
order by TotalDeathCount desc

--Highest Death Count by Continent

Select continent, MAX(cast(Total_deaths as bigint)) as TotalDeathCount
From PortfolioProject..coviddeaths$
--Where location like '%states%'
Where continent is null
Group by continent
order by TotalDeathCount desc

--Global Breakdown

Select SUM(new_cases) as total_cases, SUM(cast(new_deaths as int)) as total_deaths, SUM(cast(New_deaths as int))/SUM(New_Cases)*100 as DeathPercentage
From PortfolioProject..coviddeaths$
--Where location like '%states%'
where continent is not null
--Group by date
order by 1,2

--Population Vs Vaccinations

Select dea.continent, dea.location, dea.date, dea.population, vac.new_vaccinations
From PortfolioProject..coviddeaths$ dea
Join PortfolioProject..covidvaccines$ vac
	On dea.location = vac.location
	and dea.date = vac.date
where dea.continent is not null
order by 1,2,3


--New Vaccinations per day

Select dea.continent, dea.location, dea.date, dea.population, vac.new_vaccinations
, SUM(CONVERT(bigint,vac.new_vaccinations)) OVER (Partition by dea.Location Order by dea.location, dea.Date) as RollingPeopleVaccinated
--, (RollingPeopleVaccinated/population)*100
From PortfolioProject..coviddeaths$ dea
Join PortfolioProject..covidvaccines$ vac
	On dea.location = vac.location
	and dea.date = vac.date
where dea.continent is not null 
order by 2,3


-- Using CTE to perform Calculation on Partition By in previous query

With PopvsVac (Continent, Location, Date, Population, New_Vaccinations, RollingPeopleVaccinated)
as
(
Select dea.continent, dea.location, dea.date, dea.population, vac.new_vaccinations
, SUM(CONVERT(bigint,vac.new_vaccinations)) OVER (Partition by dea.Location Order by dea.location, dea.Date) as RollingPeopleVaccinated
--, (RollingPeopleVaccinated/population)*100
From PortfolioProject..coviddeaths$ dea
Join PortfolioProject..covidvaccines$ vac
	On dea.location = vac.location
	and dea.date = vac.date
where dea.continent is not null 
--order by 2,3
)
Select *, (RollingPeopleVaccinated/Population)*100
From PopvsVac



-- Using Temp Table to perform Calculation on Partition By in previous query

DROP Table if exists #PercentPopulationVaccinated
Create Table #PercentPopulationVaccinated
(
Continent nvarchar(255),
Location nvarchar(255),
Date datetime,
Population numeric,
New_vaccinations numeric,
RollingPeopleVaccinated numeric
)

Insert into #PercentPopulationVaccinated
Select dea.continent, dea.location, dea.date, dea.population, vac.new_vaccinations
, SUM(CONVERT(bigint,vac.new_vaccinations)) OVER (Partition by dea.Location Order by dea.location, dea.Date) as RollingPeopleVaccinated
--, (RollingPeopleVaccinated/population)*100
From PortfolioProject..coviddeaths$ dea
Join PortfolioProject..covidvaccines$ vac
	On dea.location = vac.location
	and dea.date = vac.date
--where dea.continent is not null 
--order by 2,3

Select *, (RollingPeopleVaccinated/Population)*100
From #PercentPopulationVaccinated




-- Creating View to store data for later visualizations

Create View PercentPopulationVaccinated as
Select dea.continent, dea.location, dea.date, dea.population, vac.new_vaccinations
, SUM(CONVERT(int,vac.new_vaccinations)) OVER (Partition by dea.Location Order by dea.location, dea.Date) as RollingPeopleVaccinated
--, (RollingPeopleVaccinated/population)*100
From PortfolioProject..coviddeaths$ dea
Join PortfolioProject..covidvaccines$ vac
	On dea.location = vac.location
	and dea.date = vac.date
where dea.continent is not null 





