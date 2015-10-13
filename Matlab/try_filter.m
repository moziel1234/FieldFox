%----------------------------------------------------------
xmax = 2.5; % Define the range of x.
x = -xmax:.1:xmax; 
f = @(x) exp(-x.^2); % The original function.

figure 
plot(x,f(x)); % Plot the original function.

% The analytic FT.
F = @(k) (1/sqrt(pi))*exp(-(pi^2)*(k.^2)); 
kmax = 1000; % Define the range of k.
dk = .01; % And the increment of k.
k = -kmax:dk:kmax; % The k vector for use in ifft.
lngth = length(k);
figure; plot(k,F(k));
Y = ifft(ifftshift(F(k))); % Apply the ifft.
% now fix the Y vect as suggested above.
Yfix = [Y((round(lngth/2)+1):end) Y(1:round(lngth/2))];
% Assign a range of x that will work for Y.
xp = (-(round((1/dk)/2)):(1/(2*kmax)):round((1/dk)/2));

figure
plot(xp,Yfix) % The 'not yet normalized' plot.
factor = 1/max(Yfix); % Normalize Y to it's max value
Yfix = factor*Yfix;

figure
plot(xp,Yfix) % Plot the normalized Y.
xlim([-xmax xmax])
