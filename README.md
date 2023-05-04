# federated-subscriptions-hotchocolate
Federated Schema Stitching with subgraph that supports subscriptions
This repository demonstrates that in the latest hotchocolate packages, a gateway can't work with a subgraph that supports a graphql subscribe operation.

The subgraph works fine: it exposes the subscribtion onpublished. The schema is also exposed. The gateway can validate the subsciption onpublished command, but when executing it throws: an error: "You must declare a subscribe resolver for subscription fields."

Although the subscribe resolver is declared in the subgraph.
