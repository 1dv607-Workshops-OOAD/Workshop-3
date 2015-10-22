# BlackJack

Klassdiagrammet visar inte dependencies från Rules->Interfaces till modelklasser, då det gör klassdiagrammet mer svårläst.
RulesFactory visar enbart dependencies till de olika strategiklasserna, inte till interfacen, då RulesFactory har tillgång till interfacen via realizations från strategiklasserna till interfacen.

En körbar fil finns i mappen BlackJack->Bin->Release.
