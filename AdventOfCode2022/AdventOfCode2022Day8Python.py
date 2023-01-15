
#----- algoritme for å sjekke synligheten -----#
#   For hver trelinje:
#     For hvert tre trelinjen: start med å sjekke synlighet fra venstre, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig fra venstre sjekk fra høyre, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig fra venstre eller høyre, sjekk vertikalt oppover, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig oppover, sjekk vertikalt nedover, hvis synlig så avbryt søk og legg på synligtre +1.

#Søke etter trer horisontalt fungerer
with open("DayEightInput.txt") as file:
    synligeTrer = 0
    linjer = file.readlines()
    for line in range(len(linjer)):
        trer = linjer[line].strip()
        if(line==0 or line == len(linjer)-1):
            synligeTrer+=len(linjer)
        elif(line>0 and line<len(linjer)):
            synligeTrer+=2
            for tre in range(len(trer)-2,0, -1): #for hvert tre i lengden av trelinje 
                synlig = True
                for trevenstre in range(tre-1,-1,-1): #starter med å sjekke synlighet fra venstre. 
                    if trer[tre]<=trer[trevenstre]:  #synlighet fra venstre feilet, start neste søk
                        for trehoyre in range(tre+1,len(trer)):
                            if trer[tre]<=trer[trehoyre]:    # synlighet fra høyre feilet, start vertikalt 
                                for trelinjeOppover in range(line-1,-1,-1):   
                                    if trer[tre]<= linjer[trelinjeOppover][tre]:
                                        for trelinjeNedover in range(line+1,len(linjer)):   #synlighet fra oven feilet, start søk nedover
                                            if trer[tre]<= linjer[trelinjeNedover][tre]:
                                                print("pA linje:",trelinjeNedover+1,". Index",tre,"med",trer[tre],"er ikke synlig underfra. Mot:",linjer[trelinjeNedover][tre])
                                                synlig = False
                                                break
                                        break
                                break
                        break
                if synlig:
                    synligeTrer+=1
    print(synligeTrer)