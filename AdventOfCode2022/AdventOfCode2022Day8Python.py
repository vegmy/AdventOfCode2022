
#----- algoritme for å sjekke synligheten -----#
#   For hver trelinje:
#     For hvert tre i trelinjen: start med å sjekke synlighet fra venstre, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig fra venstre sjekk fra høyre, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig fra venstre eller høyre, sjekk vertikalt oppover, hvis synlig så avbryt søk og legg på synligtre +1.
#       Dersom treet ikke er synlig oppover, sjekk vertikalt nedover, hvis synlig så avbryt søk og legg på synligtre +1.

def FinnSynligheTrer(fil):
    synligeTrer=0
    with open(fil) as file:
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
                                                    synlig = False
                                                    break
                                            break
                                    break
                            break
                    if synlig:
                        synligeTrer+=1
    return synligeTrer

def FinnMaxScenicScore(fil):
    MaxScenicScore=0
    with open(fil) as file:
        linjer = file.readlines()
        for line in range(len(linjer)):
            trer = linjer[line].strip()
            if(line>0 and line<len(linjer)):
                print("\n")
                for tre in range(1,len(trer)-1): 
                    scenicScore =0
                    Nordutsikt = 0
                    Sorutsikt = 0
                    Vestutsikt = 0
                    Ostutsikt = 0
                    for treforan in range(tre+1,len(trer)):
                        Ostutsikt+=1
                        if(trer[tre]<=trer[treforan]):
                            break
                    for trebak in range(tre-1,-1,-1):
                        Vestutsikt+=1
                        if(trer[tre]<=trer[trebak]):
                            break
                    for trelinjerNord in range(line-1,-1,-1):
                        Nordutsikt+=1
                        if trer[tre]<=linjer[trelinjerNord][tre]:
                            break
                    for trelinjerSor in range(line+1,len(linjer)):
                        Sorutsikt+=1
                        if trer[tre]<=linjer[trelinjerSor][tre]:
                            break
                    scenicScore= Nordutsikt*Sorutsikt*Vestutsikt*Ostutsikt
                  #  print("score=",scenicScore,"nord=",Nordutsikt,"sor=",Sorutsikt,"vest=",Vestutsikt,"ost=",Ostutsikt,"tre=",trer[tre])

                    if MaxScenicScore<scenicScore:
                        MaxScenicScore=scenicScore

    return MaxScenicScore



    #---- Del 1 output ----#
#print(FinnSynligheTrer("DayEightInput.txt"))

    #---- Del 2 Output ----#
print(FinnMaxScenicScore("DayEightInput.txt"))

