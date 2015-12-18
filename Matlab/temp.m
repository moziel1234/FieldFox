x = linspace(0,1,1000);

base = 4*cos(2*pi*x);

Pos = [1 2 3 5 7 8]/10;
Hgt = [3 7 5 5 4 5];
Wdt = [1 3 3 4 2 3]/100;

for n = 1:length(Pos)
    Gauss(n,:) =  Hgt(n)*exp(-((x - Pos(n))/Wdt(n)).^2);
end

PeakSig = sum(Gauss)+base;

figure; plot(x,Gauss,'--',x,PeakSig,x,base)
findpeaks(PeakSig,'MinPeakProminence',4,'Annotate','extents')