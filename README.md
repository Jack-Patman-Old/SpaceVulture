# SpaceVulture

SpaceVulture is a project aimed at providing market & portfolio analysis for the EVE Online Space MMORPG. The project makes use of various public data sources ([EMDR](http://www.eve-emdr.com/en/latest/) & [ZKillboard](https://zkillboard.com/) and feeds them into a [NOSQL - Graph Database.](http://neo4j.com) for later analysis. 

From a personal level, the project is an attempt to explore both the use of graph-databases in market-analysis & modelling as well as a personal exploration of industry areas that fall outside my current jurisdiction of market data reconcilliation (risk, modelling, analysis, etc.).

As per all input, criticism & suggestion is welcome. 

# Feature Roadmap 
## Datalayer
1. Consumption & Abstraction of the EMDR Data Feed
2. Basic CRUD utility for managing Market Data in a Neo4j client.
3. Consumption & Abstraction of ZKillboard data. 
4. Consumption of EVE Player API to view player portfolio & skills (to determine % overhead on tradess).

## Market Analysis
1. Visualisation of market trends (Price, Demand, Supply) by Item/Station/Region/System.
2. Identification, Ranking and visualisation of opportunities for either Station trading or Haul trading (with route suggestion for Haul trading taking into account security risk). 

## Portfolio Analysis
1. Visualisation of unsystematic risk on basis of market trends and portfolio diversity. Possibly with suggestion of diversification opportunities based on market analysis & risk.



